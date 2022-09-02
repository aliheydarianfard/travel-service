﻿global using Microsoft.AspNetCore.Mvc;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Design;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;
global using Microsoft.OpenApi.Models;
global using Serilog;
global using System.IO.Compression;
global using System.Reflection;
global using travel.Services.Flight.Flight.API;
global using travel.Services.FlightAPI.Infrastructure;
global using travel.Services.FlightAPI.Infrastructure.EntityConfigurations;
global using travel.BuildingBlocks.Logging.Common.Host;
global using travel.BuildingBlocks.Logging.Common.Logging;
global using Newtonsoft.Json;
global using MediatR;
global using travel.Services.FlightAPI.Domain.SeedWork;
global using travel.Services.FlightAPI.Domain.AggregatesModel.FlightAggregate;
global using travel.Services.FlightAPI.Domain.Exceptions;



