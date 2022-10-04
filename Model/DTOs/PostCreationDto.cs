namespace Model.DTOs;

public class PostCreationDto
{
    public string Body { get; }
    public string Title { get; }

    public PostCreationDto(string title, string body)
    {
        Body = body;
        Title = title;
    }
}