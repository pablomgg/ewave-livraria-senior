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

        public const string QueryById = @"
                                    SELECT 
	                                     [AggregateId]
	                                    ,[Nome]
	                                    ,[Ativo] 
                                    FROM [ToDo].[dbo].[Autor]
                                        WHERE [Id] = @AutorId;
                                    ";
    }
}