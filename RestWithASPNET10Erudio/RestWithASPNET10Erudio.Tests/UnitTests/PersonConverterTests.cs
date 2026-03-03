using FluentAssertions;
using RestWithASPNET10Erudio.Data.Converter.Impl;
using RestWithASPNET10Erudio.Data.DTO;
using RestWithASPNET10Erudio.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestWithASPNET10Erudio.Tests.UnitTests
{
    public class PersonConverterTests
    {
        private readonly PersonConverter _converter;

        public PersonConverterTests()
        {
            _converter = new PersonConverter();
        }

        [Fact]
        public void Parse_ShouldConvertPersonDTOToPerson()
        {
            var personDTO = MakePersonDto(1, "Frank", "Dog", "Bc", "Male");
            var expectedPerson = MakePerson(1, "Frank", "Dog", "Bc", "Male");
            var person = _converter.Parse(personDTO);
            person.Should().NotBeNull();
            person.Should().BeEquivalentTo(expectedPerson);

        }

        [Fact]
        public void Parse_NullPersonDTOShouldReturnNull()
        {
            PersonDTO personDTO = null;
            var person = _converter.Parse(personDTO);
            person.Should().BeNull();
        }

        [Fact]
        public void ParseList_ShouldConvertPersonDTOListToPersonList()
        {
            var personDTOs = new List<PersonDTO>
            {
                MakePersonDto(1, "Frank", "Dog", "BC", "Male"),
                MakePersonDto(2, "Frida", "Dog", "BC", "Female")
            };

            var expectedPersons = new List<Person> 
            {
                MakePerson(1, "Frank", "Dog", "BC", "Male"),
                MakePerson(2, "Frida", "Dog", "BC", "Female")
            };

            var expectedPersonsList = _converter.ParseList(personDTOs);
            expectedPersonsList.Should().NotBeNull();
            expectedPersonsList.Should().BeEquivalentTo(expectedPersons);
        }

        [Fact]
        public void ParseList_NullPersonDTOListShouldReturnNull()
        {
            List<PersonDTO> personDTOs = null;
            var persons = _converter.ParseList(personDTOs);
            persons.Should().BeNull();
        }

        [Fact]
        public void Parse_ShouldConvertPersonToPersonDTO()
        {          
            var person = MakePerson(1, "Frank", "Dog", "Bc", "Male");
            var expectedPerson = MakePersonDto(1, "Frank", "Dog", "Bc", "Male");
            var personDTO = _converter.Parse(person);
            personDTO.Should().NotBeNull();
            personDTO.Should().BeEquivalentTo(expectedPerson);

        }

        [Fact]
        public void Parse_NullPersonShouldReturnNull()
        {
            Person person = null;
            var personDTO = _converter.Parse(person);
            personDTO.Should().BeNull();
        }

        [Fact]
        public void ParseList_ShouldConvertPersonListToPersonDTOList()
        {
            var persons = new List<Person>
            {
                MakePerson(1, "Frank", "Dog", "BC", "Male"),
                MakePerson(2, "Frida", "Dog", "BC", "Female")
            };

            var expectedPersonDTOs = new List<PersonDTO> 
            {
                MakePersonDto(1, "Frank", "Dog", "BC", "Male"),
                MakePersonDto(2, "Frida", "Dog", "BC", "Female")
            };

            var expectedPersonDTOsList = _converter.ParseList(persons);
            expectedPersonDTOsList.Should().NotBeNull();
            expectedPersonDTOsList.Should().BeEquivalentTo(expectedPersonDTOs);
        }

        [Fact]
        public void ParseList_NullPersonListShouldReturnNull()
        {
            List<Person> persons = null;
            var personDTOs = _converter.ParseList(persons);
            personDTOs.Should().BeNull();
        }

        private static PersonDTO MakePersonDto(long id, string first, string last, string address, string gender)
            => new()
            {
                Id = id,
                FirstName = first,
                LastName = last,
                Address = address,
                Gender = gender
            };

        private static Person MakePerson(long id, string first, string last, string address, string gender)
            => new()
            {
                Id = id,
                FirstName = first,
                LastName = last,
                Address = address,
                Gender = gender
            };
    }
}
