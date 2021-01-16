namespace ToDo.Dapper.Queries
{
    public struct PessoaQueries
    {
        public const string Query = @"
                                    SELECT 
                                         [p].[Id]
                                        ,[p].[AggregateId]
                                        ,[p].[TipoId]
                                        ,[pt].[Nome]
                                    FROM [ToDo].[dbo].[Pessoa] AS [p]
                                        INNER JOIN [ToDo].[dbo].[PessoaTipo] AS [pt] ON [pt].[Id] = [p].[TipoId]
                                    ORDER BY [p].[DataCriacao]
                            ";

        public struct PessoaFisica
        {
            public const string QueryById = @"
                                        SELECT 
                                             [pf].[Cpf]
                                            ,[pf].[Nome]
                                        FROM [ToDo].[dbo].[Pessoa] AS [p]
                                            INNER JOIN [ToDo].[dbo].[PessoaFisica] AS [pf] ON [pf].[PessoaId] = [p].[Id]
                                        WHERE [p].[Id] = @Id
                                        ORDER BY [pf].[Nome]
                            ";
        }

        public struct PessoaJuridica
        {
            public const string QueryById = @"
                                        SELECT 
                                             [pj].[Cnpj]
                                            ,[pj].[RazaoSocial]
                                            ,[pj].[NomeFantasia]
                                        FROM [ToDo].[dbo].[Pessoa] AS [p]
                                            INNER JOIN [ToDo].[dbo].[PessoaJuridica] AS [pj] ON [pj].[PessoaId] = [p].[Id]
                                        WHERE [p].[Id] = @Id
                                        ORDER BY [pj].[RazaoSocial]
                            ";
        }

        public struct PessoaEndereco
        {
            public const string QueryById = @"
                                            SELECT
                                                 [e].[Cep]
                                                ,[e].[Bairro]
                                                ,[e].[Logradouro]
                                                ,[c].[Id] AS [CidadeId]
                                                ,[c].[Nome] AS [Cidade]
                                                ,[est].[Id] AS [EstadoId]
                                                ,[est].[Nome] AS [Estado]
                                                ,[e].[Numero]
                                                ,[e].[Complemento]
                                            FROM [ToDo].[dbo].[Pessoa] AS [p]
                                                INNER JOIN [ToDo].[dbo].[Endereco] AS [e] ON [e].[PessoaId] = [p].[Id]
                                                INNER JOIN [ToDo].[dbo].[Cidade] AS [c] ON [c].[Id] = [e].[CidadeId]
                                                INNER JOIN [ToDo].[dbo].[Estado] AS [est] ON [est].[Id] = [c].[EstadoId]
                                            WHERE [p].[Id] = @Id
                                            ORDER BY [est].[Nome]
                            ";
        }

        public struct PessoaTelefone
        {
            public const string QueryById = @"
                                            SELECT 
                                                 [t].[Id]
	                                             ,[t].[Numero]
	                                             ,[t].[TipoId]
	                                             ,[tt].[Nome] AS [Tipo]
                                            FROM [ToDo].[dbo].[Pessoa] AS [p]
                                                INNER JOIN [ToDo].[dbo].[Telefone] AS [t] ON [t].[PessoaId] = [p].[Id]
	                                            INNER JOIN [ToDo].[dbo].[TelefoneTipo] AS [tt] ON [tt].[Id] = [t].[TipoId]
                                            WHERE [p].[Id] = @Id
                                            ORDER BY [t].[Id]
                            ";
        }

        public struct PessoaEmail
        {
            public const string QueryById = @"
                                            SELECT 
                                                  [e].[Id]
	                                             ,[e].[Endereco]
	                                             ,[e].[TipoId]
	                                             ,[et].[Nome] AS [Tipo]
                                            FROM [ToDo].[dbo].[Pessoa] AS [p]
                                                INNER JOIN [ToDo].[dbo].[Email] AS [e] ON [e].[PessoaId] = [p].[Id]
	                                            INNER JOIN [ToDo].[dbo].[EmailTipo] AS [et] ON [et].[Id] = [e].[TipoId]
                                            WHERE [p].[Id] = @Id
                                            ORDER BY [e].[Id]
                            ";
        }
    }
}