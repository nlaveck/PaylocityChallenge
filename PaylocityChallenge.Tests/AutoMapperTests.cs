using AutoMapper;
using PaylocityChallenge.Api.Dtos;
using PaylocityChallenge.Core.Entities;
using PaylocityChallenge.Core.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace PaylocityChallenge.Tests
{
    public class AutoMapperTests
    {
        private MapperConfiguration sut;

        public AutoMapperTests()
        {
            sut = new MapperConfiguration(config => config.AddProfile<Mappings>());
        }

        [Fact]
        public void AutoMapperConfigurationIsValid()
        {
            sut.AssertConfigurationIsValid();
        }
    }
}
