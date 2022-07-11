using AutoMapper;
using DocLibrary.Dal.Interface;
using DocLibrary.Entity.Context;
using DocLibrary.Entity.Entities;
using DocLibrary.Helper.ApiResultHelper;
using DocLibrary.Model.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static DocLibrary.Model.Common.Enums;

namespace DocLibrary.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private IUnitOfWork<DocumentContext> _unitOfWork;

        public DocumentController(IConfiguration configuration, IMapper mapper, IUnitOfWork<DocumentContext> unitOfWork)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration), "Can not be null!");
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper), "Can not be null!");
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork), "Can not be null!");
        }

        #region GET
        [HttpGet("GetByDocumentRef/{refNumber}")]
        public async Task<ApiResult<DocumentDto>> GetByDocumentRef(string refNumber)
        {
            try
            {
                var doc = _unitOfWork.Repository<DocumentShare>().Include(x => x.Document).FirstOrDefaultAsync(x => x.ShareRef.Equals(refNumber));
                if (doc == null)
                    return new ApiResult<DocumentDto> { Result = true, Message = "Document not found!" };

                return new ApiResult<DocumentDto> { Result = true, Data = _mapper.Map<DocumentDto>(doc), Message = "Success!" };
            }
            catch (Exception ex)
            {
                // Log exception!
                return new ApiResult<DocumentDto> { Result = false, Message = $"An error occured! Ex: {ex.Message}" };
            }
        }

        [HttpGet("GetByDocumentId/{documentId}")]
        public async Task<ApiResult<DocumentDto>> GetByDocumentId(long documentId)
        {
            try
            {
                var doc = await _unitOfWork.Repository<Document>().GetByIdAsync(documentId);

                if (doc == null)
                    return new ApiResult<DocumentDto> { Result = true, Message = "Document not found!" };

                return new ApiResult<DocumentDto> { Result = true, Data = _mapper.Map<DocumentDto>(doc), Message = "Success!" };
            }
            catch (Exception ex)
            {
                // Log exception!
                return new ApiResult<DocumentDto> { Result = false, Message = $"An error occured! Ex: {ex.Message}" };
            }
        }

        [HttpGet("GetListByUserId/{userId}")]
        public async Task<ApiResult<IEnumerable<DocumentDto>>> GetListByUserId(long userId)
        {
            try
            {
                var docList = _unitOfWork.Repository<Document>()
                    .Where(x => x.UserId == userId)
                    .Select(x => _mapper.Map<DocumentDto>(x));

                return new ApiResult<IEnumerable<DocumentDto>> { Result = true, Data = docList, Message = "Success!" };
            }
            catch (Exception ex)
            {
                // Log exception
                return new ApiResult<IEnumerable<DocumentDto>> { Result = false, Message = $"An error occured! Ex: {ex.Message}" };
            }
        }
        #endregion

        #region POST
        [HttpPost("Save")]
        public async Task<ApiResult> Save([FromBody] List<DocumentDto> documentDtos)
        {
            try
            {
                foreach (var documentDto in documentDtos)
                {
                    var docEntity = _mapper.Map<Document>(documentDto);
                    await _unitOfWork.Repository<Document>().InsertAsync(docEntity);
                }

                await _unitOfWork.SaveChangesAsync();

                return new ApiResult { Result = true, Message = "Success!" };
            }
            catch (Exception ex)
            {
                // Log exception
                return new ApiResult { Result = false, Message = $"An error occured! Ex: {ex.Message}" };
            }
        }

        [HttpPost("Share")]
        public async Task<ApiResult> Share([FromBody] DocumentShareDto documentShareDto)
        {
            try
            {
                var docShare = _mapper.Map<DocumentShare>(documentShareDto);
                await _unitOfWork.Repository<DocumentShare>().InsertAsync(docShare);
                await _unitOfWork.SaveChangesAsync();

                return new ApiResult { Result = true, Message = "Success!" };
            }
            catch (Exception ex)
            {
                // Log exception
                return new ApiResult { Result = false, Message = $"An error occured! Ex: {ex.Message}" };
            }
        }
        #endregion

        #region DELETE
        [HttpDelete("Delete/{documentId}")]
        public async Task<ApiResult> Delete(long documentId)
        {
            try
            {
                var doc = await _unitOfWork.Repository<Document>().GetByIdAsync(documentId);
                if (doc == null)
                    return new ApiResult<DocumentDto> { Result = true, Message = "Document not found!" };

                doc.IsActive = false;
                _unitOfWork.Repository<Document>().Update(doc);
                await _unitOfWork.SaveChangesAsync();

                return new ApiResult { Result = true, Message = "Success!" };
            }
            catch (Exception ex)
            {
                // Log exception
                return new ApiResult { Result = false, Message = $"An error occured! Ex: {ex.Message}" };
            }
        }
        #endregion
    }
}
