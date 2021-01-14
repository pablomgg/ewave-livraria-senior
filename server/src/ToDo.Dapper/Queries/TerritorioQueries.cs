namespace ToDo.Dapper.Queries
{
    public class TerritorioQueries
    {
        public struct Estado
        {
            public const string Query = @"
                                        SELECT 
                                             [Id] 
                                            ,[Nome] 
                                            ,[Sigla] 
                                        FROM [ToDo].[dbo].[Estado]
                                        ORDER BY [Nome]
                                        ";
        }

        public struct Cidade
        {
            public const string Query = @"
                                        SELECT 
                                             [Id] 
                                            ,[Nome]
                                            ,[EstadoId]
                                        FROM [ToDo].[dbo].[Cidade]
                                        ORDER BY [Nome]
                                    ";

            public const string QueryById = @"
                                        SELECT 
                                             [Id] 
                                            ,[Nome]
                                            ,[EstadoId]
                                        FROM [ToDo].[dbo].[Cidade]
                                            WHERE [EstadoId] = @EstadoId
                                        ORDER BY [Nome]
                                    ";
        }
    }
}