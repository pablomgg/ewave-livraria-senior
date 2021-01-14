namespace ToDo.Dapper.Queries
{
    public struct UsuarioQueries
    {
        public const string Query = @"
                            SELECT 
                                 [u].[AggregateId]
                                ,[u].[PessoaAggregateId]
                                ,[u].[InstituicaoDeEnsinoAggregateId]
                                ,[u].[Ativo]
                                ,[p].[Id] AS [PessoaId]
                            FROM [ToDo].[dbo].[Usuario] AS [u]
                                INNER JOIN [ToDo].[dbo].[Pessoa] AS [p] ON [p].[AggregateId] = [u].[PessoaAggregateId]
                                INNER JOIN [ToDo].[dbo].[PessoaFisica] AS [pf] ON [pf].[PessoaId] = [p].[Id]
                            ORDER BY [pf].[Nome]
                            ";
    }
}