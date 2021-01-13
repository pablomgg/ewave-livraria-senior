namespace ToDo.Dapper.Queries
{
    public struct LivroQueries
    {
        public const string Query = @"
                                        SELECT  
                                             [l].[AggregateId]
                                            --,[a].[AggregateId] AS [AutorAggregateId]
                                            --,[g].[AggregateId] AS [GeneroAggregateId]
                                            ,[l].[Titulo]
                                            ,[l].[Sinopse]
                                            ,[l].[Paginas]
                                            ,[l].[Capa]
                                            ,[l].[Disponivel] 
                                            ,[l].[Ativo]
                                            ,[l].[AutorId]
                                            ,[l].[GeneroId]
                                        FROM [ToDo].[dbo].[Livro] AS [l]
                                        INNER JOIN [ToDo].[dbo].[Autor] AS [a] ON [a].[Id] = [l].[AutorId]
                                        INNER JOIN [ToDo].[dbo].[Genero] AS [g] ON [g].[Id] = [l].[GeneroId]
                                    "; 
    }
}