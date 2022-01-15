FROM mcr.microsoft.com/dotnet/sdk:5.0-alpine as build-ENV
#COPY /Case.Shared ./app/Case.Shared
COPY /CaseStudy.Domain ./app/CaseStudy.Domain
COPY /CaseStudy.Infrastructure ./app/CaseStudy.Infrastructure
COPY /CaseStudy.Application ./app/CaseStudy.Application
COPY /CaseStudy.API ./app/CaseStudy.API
WORKDIR /app/CaseStudy.API
RUN dotnet publish -c Release -r linux-musl-x64 -o publish-folder

FROM mcr.microsoft.com/dotnet/runtime-deps:5.0-alpine as runtime
COPY --from=build-env /app/CaseStudy.API/publish-folder ./
RUN apk add --update \
    iputils \
    curl \
    icu-libs \
    && rm -rf /var/cache/apk/*
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
ENV ASPNETCORE_ENVIRONMENT=Development
ENTRYPOINT ["./CaseStudy.API"]