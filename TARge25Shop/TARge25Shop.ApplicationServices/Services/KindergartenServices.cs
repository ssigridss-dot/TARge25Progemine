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

        public KindergartenServices
            (
                TARge25ShopContext context,
                IFileServices fileServices
            )
        {
            _context = context;
            _fileServices = fileServices;
        }

        //see meetod on vaja controlleris esile kutsuda
        //peab lisama interface, et kutsuda see meetod välja
        public async Task<Kindergarten> Create(KindergartenDto dto)
        {
            //siin peab tegema vaheinstansi dto ja domain vahel,
            //et andmed liiguvad dto-st domain objekt
            Spaceship spaceShip = new();

            kinderGarten.Id = Guid.NewGuid();
            kindergarten.GroupName = dto.GroupName;
            kinderGarten.ChildrenCount = dto.ChildrenCount;
            kinderGarten.Name = dto.Name;
            kinderGarten.TeacherName = dto.TeacherName;
            kinderGarten.CreatedAt = DateTime.Now;
            kinderGarten.UpdatedAt = DateTime.Now;
            //kui uus ankeet on loodud, siis
            //toimub ka faili salvestamine
            //saab kutsuda teise service classi meetotit
            //esile service classis
            _fileServices.FilesToApi(dto, kinderGarten);

            //andmete salvestamine andmebaasi
            _context.Kindergartens.Add(kinderGarten);
            await _context.SaveChangesAsync();

            return kinderGarten;
        }

        //teha update meetod, mis võtab vastu dto ja uuendab olemasolevat kosmoselaeva
        public async Task<Kindergarten> Update(KindergartenDto dto)
        {
            //siin peab tegema vaheinstansi dto ja domain vahel,
            //et andmed liiguvad dto-st domain objekt
            Kindergarten kinderGarten = new();

            kinderGarten.Id = dto.Id;
            kinderGarten.GroupName = dto.GroupName;
            kinderGarten.ChildrenCount = dto.ChildrenCount;
            kinderGarten.Name = dto.Name;
            kinderGarten.TeacherName = dto.TeacherName;
            kinderGarten.CreatedAt = dto.CreatedAt;
            kinderGarten.UpdatedAt = DateTime.Now;
            //lisame juurde piltide lisamise
            _fileServices.FilesToApi(dto, kinderGarten);

            //andmete uuendamine andmebaasis
            _context.Kindergartens.Update(kinderGarten);
            await _context.SaveChangesAsync();

            return kinderGarten;
        }

        public async Task<Kindergarten> DetailAsync(Guid id)
        {
            var kindergarten = await _context.Kindergartens
                .FirstOrDefaultAsync(x => x.Id == id);

            return kindergarten;
        }

        public async Task<Kindergaten> Delete(Guid id)
        {
            var result = await _context.Kindergartens
                .FirstOrDefaultAsync(x => x.Id == id);

           
           
            _context.Kindergartens.Remove(result);
            await _context.SaveChangesAsync();

            return result;
        }
    }
}
