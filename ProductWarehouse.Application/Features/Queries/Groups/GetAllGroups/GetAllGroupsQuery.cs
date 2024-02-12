﻿using MediatR;
using ProductWarehouse.Application.Models;

namespace ProductWarehouse.Application.Features.Queries.Groups.GetAllGroups;

public record GetAllGroupsQuery() : IRequest<List<GroupDto>>;