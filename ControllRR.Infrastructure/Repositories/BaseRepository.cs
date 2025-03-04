using System.Linq.Expressions;
using ControllRR.Domain.Interfaces;
using ControllRR.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace ControllRR.Infrastructure.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        protected readonly ControllRRContext _context;

        protected BaseRepository(ControllRRContext context)
        {
            _context = context;
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await Task.CompletedTask;
        }

        public async Task RemoveAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await Task.CompletedTask;
        }
        // (Nova nota )Para referencia - > Por hora estou usando em stockService(search) e em purchaseOrderService(Search) para retornar valores
        // sem a necessidade de repetição em cada repository. Pretendo a medida de que for necessario tais repetições, incluir novos metodos aqui e simplificar
        // os demais repo.(fim nova nota)
        // Constrói a expressão OR dinamicamente
        // Vou testar, porque no service eu tive muitos problemas. 
        // Na verdade não quero ter que repetir esse metodo para todo mundo, acho que ainda é a forma mais inteligente.
        // Está apresentando erro com as movimentações. Acredito que seja alguma coisa com o dotnet no debian. Vou testar mais tarde
        public virtual async Task<List<T>> SearchAsync(string term,
            Expression<Func<T, bool>> additionalFilter = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null,
            params Expression<Func<T, string>>[] propertySelectors)
        {
            var query = _context.Set<T>().AsQueryable();

            if (includes != null)
            {
                query = includes(query);
            }

            var parameter = Expression.Parameter(typeof(T), "x");
            Expression body = null;

            foreach (var selector in propertySelectors)
            {
                var selectorLambda = selector;
                var selectorBody = selectorLambda.Body;
                var selectorParam = selectorLambda.Parameters[0];

                // Rebinding do parâmetro do seletor para o parâmetro principal (x)
                var rebinder = new ParameterRebinder(selectorParam, parameter);
                var rebindedBody = rebinder.Visit(selectorBody);

                // Verifica se o valor é nulo (para propriedades do tipo string)
                var nullCheck = Expression.NotEqual(rebindedBody, Expression.Constant(null, typeof(string)));
                // Método Contains
                var containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });
                var containsCall = Expression.Call(rebindedBody, containsMethod, Expression.Constant(term));
                // Combina a verificação de nulidade com o Contains
                var condition = Expression.AndAlso(nullCheck, containsCall);

                body = body == null ? condition : Expression.OrElse(body, condition);
            }

            // Combina com o filtro adicional, se houver
            if (additionalFilter != null)
            {
                var additionalBody = additionalFilter.Body;
                var rebinder = new ParameterRebinder(additionalFilter.Parameters[0], parameter);
                var rebindedAdditionalBody = rebinder.Visit(additionalBody);

                body = body != null
                    ? Expression.AndAlso(body, rebindedAdditionalBody)
                    : rebindedAdditionalBody;
            }

            if (body == null)
                return await query.ToListAsync();

            var lambda = Expression.Lambda<Func<T, bool>>(body, parameter);
            return await query.Where(lambda).ToListAsync();
        }

        // Classe auxiliar para rebind de parâmetros
        // Devo mudar isso para um outro lugar e deixar ela desacoplada deo meu baserepository, porém, antes devo terminar de solucionar algumas coisas
        private class ParameterRebinder : ExpressionVisitor
        {
            private readonly ParameterExpression _oldParameter;
            private readonly ParameterExpression _newParameter;

            public ParameterRebinder(ParameterExpression oldParameter, ParameterExpression newParameter)
            {
                _oldParameter = oldParameter;
                _newParameter = newParameter;
            }

            protected override Expression VisitParameter(ParameterExpression node)
            {
                return node == _oldParameter ? _newParameter : node;
            }
        }
    }
}