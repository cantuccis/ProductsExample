namespace Backend;

public readonly struct ReceiveProductTransaction
{
    public ReceiveProductTransaction()
    {
    }
    public int ProductId { get; init; } = -1;
    public int Quantity { get; init; } = -1;
    public DateTime Date { get; init; } = DateTime.Now;
}