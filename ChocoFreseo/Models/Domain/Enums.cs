namespace ChocoFreseo.Models.Domain
{
    public enum EstadoPedido
    {
        Pendiente = 0,
        Preparando = 1,
        Listo = 2,
        Entregado = 3,
        Cancelado = 4
    }

    public enum EstadoDomicilio
    {
        Pendiente = 0,
        Asignado = 1,
        EnRuta = 2,
        Entregado = 3,
        Cancelado = 4
    }
}
