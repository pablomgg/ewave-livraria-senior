namespace ToDo.Dapper.Queries
{
    public struct InstituicaoDeEnsinoQueries
    {
        public const string Query = @"
                                    SELECT 
                                         [i].[AggregateId]
                                        ,[i].[PessoaAggregateId]
                                        ,[i].[Ativo]
                                        ,[p].[Id] AS [PessoaId]
                                    FROM [ToDo].[dbo].[InstituicaoDeEnsino] AS [i]
                                        INNER JOIN [ToDo].[dbo].[Pessoa] AS [p] ON [p].[AggregateId] = [i].[PessoaAggregateId]
                                        INNER JOIN [ToDo].[dbo].[PessoaJuridica] AS [pj] ON [pj].[PessoaId] = [p].[Id]
                                    ORDER BY [pj].[RazaoSocial]
                            ";

        public const string QueryByAggregateId = @"
                                    SELECT 
                                         [i].[AggregateId]
                                        ,[i].[PessoaAggregateId]
                                        ,[i].[Ativo]
                                        ,[p].[Id] AS [PessoaId]
                                    FROM [ToDo].[dbo].[InstituicaoDeEnsino] AS [i]
                                        INNER JOIN [ToDo].[dbo].[Pessoa] AS [p] ON [p].[AggregateId] = [i].[PessoaAggregateId]
                                        INNER JOIN [ToDo].[dbo].[PessoaJuridica] AS [pj] ON [pj].[PessoaId] = [p].[Id]
                                        WHERE [i].[AggregateId] = @AggregateId
                                    ORDER BY [pj].[RazaoSocial]
                            ";
    }
}