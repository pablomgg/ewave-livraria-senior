namespace ToDo.Dapper.Queries
{
    public struct AutorQueries
    {
        public const string Query = @"
                                    SELECT 
	                                     [AggregateId]
	                                    ,[Nome]
	                                    ,[Ativo] 
                                    FROM [ToDo].[dbo].[Autor]
                                    ORDER BY [Nome]
                                    ";
    }
}