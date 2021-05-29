using System;
using System.Collections.Generic;
using FluentValidation.TestHelper;
using NUnit.Framework;
using Orso.Arpa.Application.MusicianProfileApplication;

namespace Orso.Arpa.Application.Tests.ValidationTests
{
    [TestFixture]
    public class MusicianProfileCreateDtoValidatorTests
    {
        private MusicianProfileCreateBodyDtoValidator _bodyValidator;
        private DoublingInstrumentCreateDtoValidator _doublingInstrumentValidator;

        [SetUp]
        public void Setup()
        {
            _bodyValidator = new MusicianProfileCreateBodyDtoValidator();
            _doublingInstrumentValidator = new DoublingInstrumentCreateDtoValidator();
        }

        [Test]
        public void Should_Have_Validation_Error_If_LevelAssessmentPerformer_Is_Out_Of_Range()
        {
            _bodyValidator.ShouldHaveValidationErrorFor(command => command.LevelAssessmentPerformer, (byte)6);
        }

        [Test]
        public void Should_Not_Have_Validation_Error_If_LevelAssessmentPerformer_Is_In_Range([Values(0, 1, 5)] byte x)
        {
            _bodyValidator.ShouldNotHaveValidationErrorFor(command => command.LevelAssessmentPerformer, x);
        }

        [Test]
        public void Should_Have_Validation_Error_If_Empty_QualificationId_Is_Supplied()
        {
            _bodyValidator.ShouldHaveValidationErrorFor(command => command.QualificationId, Guid.Empty);
        }

        [Test]
        public void Should_Not_Have_Validation_Error_If_Valid_QualificationId_Is_Supplied()
        {
            _bodyValidator.ShouldNotHaveValidationErrorFor(command => command.QualificationId, Guid.NewGuid());
        }

        [Test]
        public void Should_Have_Validation_Error_If_Empty_InstrumentId_Is_Supplied()
        {
            _bodyValidator.ShouldHaveValidationErrorFor(command => command.InstrumentId, Guid.Empty);
        }

        [Test]
        public void Should_Not_Have_Validation_Error_If_Valid_InstrumentId_Is_Supplied()
        {
            _bodyValidator.ShouldNotHaveValidationErrorFor(command => command.InstrumentId, Guid.NewGuid());
        }

        [Test]
        public void Should_Have_Validation_Error_If_Comment_Exceeds_Max_Length()
        {
            _doublingInstrumentValidator.ShouldHaveValidationErrorFor(command => command.Comment, new string('#', 501));
        }

        [Test]
        public void Should_Not_Have_Validation_Error_If_Valid_Comment_Is_Supplied()
        {
            _doublingInstrumentValidator.ShouldNotHaveValidationErrorFor(command => command.Comment, new string('#', 500));
        }

        [Test]
        public void Should_Have_Validation_Error_If_Empty_DoublingInstrumentId_Is_Supplied()
        {
            _doublingInstrumentValidator.ShouldHaveValidationErrorFor(command => command.InstrumentId, Guid.Empty);
        }

        [Test]
        public void Should_Not_Have_Validation_Error_If_Valid_DoublingInstrumentId_Is_Supplied()
        {
            _doublingInstrumentValidator.ShouldNotHaveValidationErrorFor(command => command.InstrumentId, Guid.NewGuid());
        }

        [Test]
        public void Should_Have_Validation_Error_If_DoublingInstrument_LevelAssessmentPerformer_Is_Out_Of_Range()
        {
            _doublingInstrumentValidator.ShouldHaveValidationErrorFor(command => command.LevelAssessmentPerformer, (byte)6);
        }

        [Test]
        public void Should_Not_Have_Validation_Error_If_DoublingInstrument_LevelAssessmentPerformer_Is_In_Range([Values(0, 1, 5)] byte x)
        {
            _doublingInstrumentValidator.ShouldNotHaveValidationErrorFor(command => command.LevelAssessmentPerformer, x);
        }

        [Test]
        public void Should_Have_Validation_Error_If_DoublingInstrument_LevelAssessmentStaff_Is_Out_Of_Range()
        {
            _doublingInstrumentValidator.ShouldHaveValidationErrorFor(command => command.LevelAssessmentStaff, (byte)6);
        }

        [Test]
        public void Should_Not_Have_Validation_Error_If_DoublingInstrument_LevelAssessmentStaff_Is_In_Range([Values(0, 1, 5)] byte x)
        {
            _doublingInstrumentValidator.ShouldNotHaveValidationErrorFor(command => command.LevelAssessmentStaff, x);
        }

        [Test]
        public void Should_Have_Validation_Error_If_PreferredPositionsPerformer_Contains_Empty_Guid()
        {
            _bodyValidator.ShouldHaveValidationErrorFor(dto => dto.PreferredPositionsPerformerIds, new List<Guid>() { Guid.Empty });
        }

        [Test]
        public void Should_Not_Have_Validation_Error_If_PreferredPositionsPerformer_Contains_Valid_Guid()
        {
            _bodyValidator.ShouldNotHaveValidationErrorFor(dto => dto.PreferredPositionsPerformerIds, new List<Guid>() { Guid.NewGuid() });
        }

        [Test]
        public void Should_Have_Validation_Error_If_PreferredPositionsStaff_Contains_Empty_Guid()
        {
            _bodyValidator.ShouldHaveValidationErrorFor(dto => dto.PreferredPositionsStaffIds, new List<Guid>() { Guid.Empty });
        }

        [Test]
        public void Should_Not_Have_Validation_Error_If_PreferredPositionsStaff_Contains_Valid_Guid()
        {
            _bodyValidator.ShouldNotHaveValidationErrorFor(dto => dto.PreferredPositionsStaffIds, new List<Guid>() { Guid.NewGuid() });
        }
    }
}