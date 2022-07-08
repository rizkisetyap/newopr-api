using Microsoft.EntityFrameworkCore;
using My_OPR.Data;
using My_OPR.Models.Master;
using My_OPR.Lib;

namespace My_OPR.Repositories.Data
{
    public class SliderRepository : GenericRepository<ApplicationDBContext, Slider, int>
    {
        private readonly ApplicationDBContext _context;
        public SliderRepository(ApplicationDBContext context) : base(context)
        {
            _context = context;
        }

        public List<Slider> GetAll()
        {
            return _context.Sliders.Where(x => x.IsDelete == false).ToList();
        }

        public int SoftDelete(int id)
        {
            var data = _context.Sliders.Find(id);
            if (data != null)
            {
                data.IsDelete = true;
                _context.Entry(data).State = EntityState.Modified;
            }
            var result = _context.SaveChanges();
            return result;
        }
        public Slider InsertSlider(ViewModels.SliderVM model)
        {
            if (model.slider == null)
            {
                throw new ArgumentNullException("Object is null");
            }
            try
            {
                _context.Sliders.Add(model.slider);
                _context.SaveChanges();
                var idSlider = model.slider.Id;
                var slider = model.slider;
                string imgPath;
                if (model.image != null)
                {
                    var path = Path.Combine("public", "upload", "slider");
                    var isExist = System.IO.Directory.Exists(path);
                    if (!isExist)
                    {
                        System.IO.Directory.CreateDirectory(path);
                    }
                    var base64str = model.image.base64str;
                    base64str = base64str.Substring(base64str.IndexOf(',') + 1);
                    Byte[] bytes = Convert.FromBase64String(base64str);
                    var fileName = "Slider - " + idSlider;
                    imgPath = UploadLib.SliderUpload(bytes, fileName, path, model.image.extension);
                    model.slider.Path = imgPath;
                    _context.SaveChanges();
                }
                return model.slider;
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        public Slider UploadSlider(ViewModels.SliderVM model)
        {
            if (model.slider == null)
            {
                throw new ArgumentNullException("Slider is null");
            }
            try
            {
                Slider slider = model.slider;
                _context.Entry(slider).State = EntityState.Modified;
                _context.SaveChanges();
                var Id = slider.Id;
                string imgPath;
                if (model.image != null)
                {
                    var path = Path.Combine("public", "upload", "slider");
                    var base64str = model.image.base64str;
                    base64str = base64str.Substring(base64str.IndexOf(',') + 1);
                    Byte[] bytes = Convert.FromBase64String(base64str);
                    var fileName = "Slider - " + Id;
                    imgPath = UploadLib.SliderUpload(bytes, fileName, path, model.image.extension);
                    model.slider.Path = imgPath;
                    _context.SaveChanges();
                }

                return model.slider;

            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
