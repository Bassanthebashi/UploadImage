namespace UploadImage.helpers
{
    public static class Helper
    {
        public static string GetFullFilePath(IFormFile file, out string savedFileName)
        {
            var folderRelativePath = Path.Combine("Assets", "Images");
            var folderFullPath = Path.Combine(Directory.GetCurrentDirectory(), folderRelativePath);
            savedFileName = $"{Guid.NewGuid()}_{file.FileName}";
            var fullFileToSavePath = Path.Combine(folderFullPath, savedFileName);
            return fullFileToSavePath;
        }
        public static void SaveFileToDirectory(IFormFile file,string fullFileToSavePath)
        {
            using (var stream = new FileStream(fullFileToSavePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
        }
    }
}
