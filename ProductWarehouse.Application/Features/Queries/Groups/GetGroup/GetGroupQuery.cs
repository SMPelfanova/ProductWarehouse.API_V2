﻿using MediatR;
using ProductWarehouse.Application.Models.Group;

namespace ProductWarehouse.Application.Features.Queries.Groups.GetGroup;

public record GetGroupQuery(Guid Id) : IRequest<GroupDto>;