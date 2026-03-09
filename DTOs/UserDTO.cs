namespace DTOs
{
    public record UserDTO
    (
        int UserId,
        string Email,
        string FirstName,
        string LastName,
        string Password,
        bool IsAdmin,
        ICollection<OrderDTO> Orders
    );
}
