using System.Data;
using AutoMapper;
using ControllRR.Application.Dto;
using ControllRR.Domain.Interfaces;

namespace ControllRR.Application.Interfaces;


public class BusinessCompanyService : IBusinessCompanyService
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public BusinessCompanyService(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<BusinessCompanyDto> GetBusinessCompanyAsync(int id)
    {//

        await _uow.BeginTransactionAsync();
        var businessRepo = _uow.GetRepository<IBusinessCompanyRepository>();
        var result = await businessRepo.GetBusinessCompanyAsync(id);
        return _mapper.Map<BusinessCompanyDto>(result);
    }

    /// <summary>
    /// Cria um novo registro de uma empresa
    /// </summary>
    /// <param name="companyDto"></param>
    /// <returns>Um conjunto de valores do tipo OperationResultDto false ou true</returns>
    public async Task<OperationResultDto> AddBusinessCompanyAsync(BusinessCompanyDto companyDto)
    {
        try
        {
            var company = _mapper.Map<BusinessCompany>(companyDto);
            await _uow.BeginTransactionAsync();
            var companyRepo = _uow.GetRepository<IBusinessCompanyRepository>();
            await companyRepo.AddAsync(company);
            return new OperationResultDto { Success = false, AlertScript = "Operação realizada com sucesso" };
        }
        catch (DBConcurrencyException ex)
        {
            return new OperationResultDto { Success = false, AlertScript = ex.Message };
            //await _uow.RollbackAsync();
        }

    }

    /// <summary>
    /// Realiza a atualização da empresa conforme dados passados para o metodo
    /// </summary>
    /// <param name="companyDto"></param>
    /// <returns>OperationResultDto(false ou true)</returns>
    public async Task<OperationResultDto> UpdateBusinessCompanyAsync(BusinessCompanyDto companyDto)
    {

        try
        {
            // Inicia a transação
            await _uow.BeginTransactionAsync();
            // realiza mapeamento de BusinessCompany para BusinessCompany
            var company = _mapper.Map<BusinessCompany>(companyDto);
            // Obtem o repositorio associado a classe()
            var companyRepo = _uow.GetRepository<IBusinessCompanyRepository>();
            // realiza o update usando o repositorio e o metodo do BaseRepository(Genérico)
            await companyRepo.UpdateAsync(company);
            // Caso não aconteceça falha, salva a transação
            await _uow.SaveChangesAsync();
            // O commit finaliza a transaçao fconfirmando todo o processo
            await _uow.CommitAsync();
            // retorna uma operationResultDto com 'sucess=true'
            return new OperationResultDto { Success = true };
        }
        catch (Exception ex)
        { 
            // caso não seja possivel realizar a transação com update, então é feito todo processo de rollback
            //await _uow.RollbackAsync();
            // retorna uma operationResultDto com 'sucess=false' e 'Message'= exceção capturada.
            throw new Exception(ex.Message);

        }
    }

    /// <summary>
    /// Realiza a busca por diversas empresas registradas na base de dados
    /// </summary>
    /// <returns>Lista de Empresas caso ok e uma exception se não for possivel determinar a recuperação de dados</returns>
    /// <exception cref="Exception"></exception>
    public async Task<List<BusinessCompanyDto>> GetAllCompanyData()
    {
        try
        {   // inicia a transação
            await _uow.BeginTransactionAsync();
            // atribui a variavel(esquerda) o repositorio obtido através do UnitOfWork
            var businessRepo = _uow.GetRepository<IBusinessCompanyRepository>();
            // faz a busca pelas empresas registradas(em caso de ter mais de uma)
            var item = await businessRepo.FindAllBusinessCompaniesAsync();
            // retorna uma lista de empresas caso exista mais de uma.
            return _mapper.Map<List<BusinessCompanyDto>>(item);
        }
        catch (Exception ex)// captura uma provavel exception no caso de algum problema durante a busca
        {
            // caso não seja possivel recuperar e retornar as empresas, então retorna uma mensagem contendo o erro(Vou fixar isso também)
            throw new Exception(ex.Message);
        }
    }


}