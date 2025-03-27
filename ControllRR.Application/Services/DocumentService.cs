using AutoMapper;
using ControllRR.Application.Dto;
using ControllRR.Application.Interfaces;
using ControllRR.Domain.Entities;
using ControllRR.Domain.Interfaces;

namespace ControllRR.Application.Services;

public class DocumentService : IDocumentService
{
    //private readonly IDocumentRepository _documentRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _uow;

    private readonly IFileStorageService _fileStorageService;

    public DocumentService(
        IDocumentRepository documentRepository,
        IMapper mapper,
        IFileStorageService fileStorageService,
        IUnitOfWork uow
        )
    {
        //_documentRepository = documentRepository;
        _mapper = mapper;
        _fileStorageService = fileStorageService;
        _uow = uow;
    }

    public async Task<IEnumerable<DocumentDto>> GetAllAsync()
    {
        try
        {
            await _uow.BeginTransactionAsync();
            var documentRepo = _uow.GetRepository<IDocumentRepository>();
            var documents = await documentRepo.GetAllAsync();
            return _mapper.Map<IEnumerable<DocumentDto>>(documents);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

    }

    public async Task AddAsync(DocumentDto documentDto)
    {
        try
        {
            await _uow.BeginTransactionAsync();
            var documentRepo = _uow.GetRepository<IDocumentRepository>();
            var document = _mapper.Map<Document>(documentDto);
            await documentRepo.AddAsync(document);
            await _uow.SaveChangesAsync();
            await _uow.CommitAsync();

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<DocumentDto> UploadDocumentAsync(DocumentDto documentDto)
    {
        if (documentDto.FormFile == null || documentDto.FormFile.Length == 0)
        {
            throw new ArgumentException("Arquivo não fornecido.");

        }
        try
        {
            await _uow.BeginTransactionAsync();
            var documentRepo = _uow.GetRepository<IDocumentRepository>();
            string uniqueFileName = await _fileStorageService.SaveFileAsync(documentDto.FormFile, "uploads");

            documentDto.DocumentName = uniqueFileName;
            documentDto.UploadedAt = DateTime.Now;

            var document = _mapper.Map<Document>(documentDto);
            await documentRepo.AddAsync(document);
            await _uow.SaveChangesAsync();
            await _uow.CommitAsync();
            return documentDto;
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Erro ao salvar arquivo{ex.Message}.");
        }

    }

    public async Task DeleteAsync(int id)
    {
        try
        {
            await _uow.BeginTransactionAsync();
            var documentRepo = _uow.GetRepository<IDocumentRepository>();
            await documentRepo.DeleteAsync(id);
            await _uow.SaveChangesAsync();
            await _uow.CommitAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}