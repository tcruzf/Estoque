using System.Reflection;
using ControllRR.Domain.Interfaces;
using ControllRR.Infrastructure.Data.Context;
using ControllRR.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

public class UnitOfWork : IUnitOfWork
{
    private readonly ControllRRContext _context;
    private IDbContextTransaction _transaction;
    private readonly Dictionary<Type, object> _repositories = new();

    public UnitOfWork(ControllRRContext context)
    {
        _context = context;
    }

    public DbContext Context => _context;

    public async Task<IDbContextTransaction> BeginTransactionAsync()
    {
        if (_transaction != null)
            throw new InvalidOperationException("Transação já iniciada.");
        _transaction = await _context.Database.BeginTransactionAsync();
        return _transaction;
    }

    public T GetRepository<T>() where T : class
    {
        var type = typeof(T);
        if (_repositories.TryGetValue(type, out var repo))
            return (T)repo;

        // Se T for uma interface de repositório customizada
        if (typeof(T).IsInterface)
        {
            var repoType = Assembly.GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.IsClass && !t.IsAbstract && typeof(T).IsAssignableFrom(t));

            if (repoType != null)
            {
                var repository = Activator.CreateInstance(repoType, _context);
                _repositories.Add(type, repository);
                return (T)repository;
            }
        }

        throw new InvalidOperationException($"Repositório não encontrado para o tipo {type.Name}");
    }

    public async Task CommitAsync()
    {
        if (_transaction == null)
            throw new InvalidOperationException("Nenhuma transação ativa.");


        await _transaction.CommitAsync();
        _transaction = null;
    }

    public async Task RollbackAsync()
    {
        if (_transaction != null)
        {
            System.Console.WriteLine("Fazendo Rollback da parada toda");
            await _transaction.RollbackAsync();
            _transaction = null;
        }
    }

    public void Dispose()
    {
        // Garante que a transação será descartada se não for nula
        // Pelo menos foi isso que eu aprendi no decorrer de 7 dias batendo cabeça por conta de uma chamada sem await...
        // kkkkkk
        _transaction?.Dispose();
        _context.Dispose();
    }

    public async ValueTask DisposeAsync()
    {
        // Garante que a transação será descartada de forma assíncrona, se necessário
        if (_transaction != null)
            await _transaction.DisposeAsync();

        await _context.DisposeAsync();
    }

    // Método adicional para garantir que todas as transações e conexões sejam limpas após cada operação
    public async Task HandleExceptionAsync(Exception ex)
    {
        // Se houver uma exceção, faça rollback e feche a transação e contexto
        if (_transaction != null)
        {
            await RollbackAsync();
        }

        await DisposeAsync();
        // Aqui você pode registrar ou rethrow a exceção
        throw ex;
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }
}
