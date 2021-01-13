namespace ToDo.Dapper.Queries
{
    public struct GeneroQueries
    {
        public const string Query = @"
                                    SELECT 
	                                     [AggregateId]
	                                    ,[Nome]
	                                    ,[Ativo] 
                                    FROM [ToDo].[dbo].[Genero]
                                    ORDER BY [Nome]
                                    ";
    }
}