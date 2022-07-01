namespace UploadImage.DTOs
{
    public record ProductReadDTO
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
    }
}
