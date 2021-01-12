FROM mcr.microsoft.com/mssql/server:2019-latest

EXPOSE 1433

ENV ACCEPT_EULA=${ACCEPT_EULA:-Y}
ENV SA_PASSWORD=${SA_PASSWORD:-JacareB@nguela1}
ENV DATABASE=${DATABASE:-ToDo}

COPY ./server/scripts/ /
ENTRYPOINT [ "/bin/bash", "./entrypoint.sh" ]
CMD [ "/opt/mssql/bin/sqlservr" ]