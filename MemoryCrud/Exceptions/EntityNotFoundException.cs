namespace MemoryCrud.Exceptions
{
    // Exceção personalizada para entidades não encontradas
    class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(int id) : base($"Entity Id {id} not found.") { }
    }
}
