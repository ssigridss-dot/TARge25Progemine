using Microsoft.EntityFrameworkCore;
using TARge25Shop.Core.Domain;
using TARge25Shop.Core.Dto;
using TARge25Shop.Core.ServiceInterface;
using TARge25Shop.Data;

namespace TARge25Shop.ApplicationServices.Services
{
    public class KindergartenServices : IKindergartenServices
    {
        private readonly TARge25ShopContext _context;
        private readonly IFileServices _fileServices;

        public KindergartenServices(
            TARge25ShopContext context,
            IFileServices fileServices)
        {
            _context = context;
            _fileServices = fileServices;
        }

        public async Task<Kindergarten> Create(KindergartenDto dto)
        {
            Kindergarten kindergarten = new();

            kindergarten.Id = Guid.NewGuid();
            kindergarten.GroupName = dto.GroupName;
            kindergarten.ChildrenCount = dto.ChildrenCount;
            kindergarten.KindergartenName = dto.KindergartenName;
            kindergarten.TeacherName = dto.TeacherName;
            kindergarten.CreatedAt = DateTime.Now;
            kindergarten.UpdatedAt = DateTime.Now;

            // Failide salvestamine
            _fileServices.FilesToApi(dto, kindergarten);

            _context.Kindergartens.Add(kindergarten);
            await _context.SaveChangesAsync();

            return kindergarten;
        }

        public async Task<Kindergarten> Update(KindergartenDto dto)
        {
            // PARANDUS: Otsime olemasoleva kirje andmebaasist üles, et vältida vigu ja säilitada CreatedAt
            var kindergarten = await _context.Kindergartens
                .FirstOrDefaultAsync(x => x.Id == dto.Id);

            if (kindergarten == null)
            {
                return null;
            }

            kindergarten.GroupName = dto.GroupName;
            kindergarten.ChildrenCount = dto.ChildrenCount;
            kindergarten.KindergartenName = dto.KindergartenName;
            kindergarten.TeacherName = dto.TeacherName;
            kindergarten.UpdatedAt = DateTime.Now;

            // Uute piltide lisamine, kui neid valiti
            _fileServices.FilesToApi(dto, kindergarten);

            _context.Kindergartens.Update(kindergarten);
            await _context.SaveChangesAsync();

            return kindergarten;
        }

        public async Task<Kindergarten> DetailAsync(Guid id)
        {
            var kindergarten = await _context.Kindergartens
                .FirstOrDefaultAsync(x => x.Id == id);

            return kindergarten;
        }

        public async Task<Kindergarten> Delete(Guid id)
        {
            var kindergarten = await _context.Kindergartens
                .FirstOrDefaultAsync(x => x.Id == id);

            if (kindergarten == null)
            {
                return null;
            }

            // PARANDUS: Leiame üles ka kõik selle lasteaia seotud pildid ja kustutame need kettalt + baasist
            var images = await _context.FileToApis
                .Where(x => x.KindergartenId == id)
                .ToArrayAsync();

            if (images.Length > 0)
            {
                // Teisendame FileToApi massiivi FileToApiDto massiiviks, et kasutada Sinu olemasolevat RemoveImagesFromApi meetodit
                var imageDtos = images.Select(x => new FileToApiDto { Id = x.Id }).ToArray();
                await _fileServices.RemoveImagesFromApi(imageDtos);
            }

            _context.Kindergartens.Remove(kindergarten);
            await _context.SaveChangesAsync();

            return kindergarten;
        }
    }
}