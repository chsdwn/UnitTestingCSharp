using System;
using System.Collections.Generic;
using System.Linq;
using LetsTest.Mocking;
using Moq;
using NUnit.Framework;

namespace LetsTest.NUnitTests.Mocking
{
    [TestFixture]
    public class HouseKeeperServiceTests
    {
        private Mock<IStatementGenerator> _statementGenerator;
        private Mock<IEmailSender> _emailSender;
        private Mock<IXtraMessageBox> _messageBox;
        private HouseKeeperService _service;
        private DateTime _statementDate = new DateTime(2020, 1, 1);
        private Housekeeper _housekeeper;
        private string _statementFileName = "filename";

        [SetUp]
        public void SetUp()
        {
            _housekeeper = new Housekeeper { Email = "a", FullName = "b", Oid = 1, StatementEmailBody = "c" };

            var unitOfWork = new Mock<IUnitOfWork>();
            unitOfWork
                .Setup(uow => uow.Query<Housekeeper>())
                .Returns(new List<Housekeeper>
                {
                    _housekeeper
                }.AsQueryable());

            _statementFileName = "filename";
            _statementGenerator = new Mock<IStatementGenerator>();
            _statementGenerator
                .Setup(sg => sg.SaveStatement(
                    _housekeeper.Oid,
                    _housekeeper.FullName,
                    _statementDate))
                .Returns(() => _statementFileName);

            _emailSender = new Mock<IEmailSender>();
            _messageBox = new Mock<IXtraMessageBox>();

            _service = new HouseKeeperService(
                unitOfWork.Object,
                _statementGenerator.Object,
                _emailSender.Object,
                _messageBox.Object);
        }

        [Test]
        public void SendStatementEmails_WhenCalled_GenerateStatements()
        {
            _service.SendStatementEmails(_statementDate);

            _statementGenerator.Verify(sg => sg.SaveStatement(
                _housekeeper.Oid,
                _housekeeper.FullName,
                _statementDate));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void SendStatementEmails_HouseKeepersEmailIsGivenArg_ShouldNotGenerateStatements(string email)
        {
            _housekeeper.Email = email;
            _service.SendStatementEmails(_statementDate);

            _statementGenerator.Verify(
                sg => sg.SaveStatement(
                    _housekeeper.Oid,
                    _housekeeper.FullName,
                    _statementDate),
                Times.Never);
        }

        [Test]
        public void SendStatementEmails_WhenCalled_EmailTheStatement()
        {
            _service.SendStatementEmails(_statementDate);

            _emailSender.Verify(es => es.EmailFile(
                _housekeeper.Email,
                _housekeeper.StatementEmailBody,
                _statementFileName,
                It.IsAny<string>()));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void SendStatementEmails_StatementFileNameIsGivenArg_ShouldNotEmailTheStatement(string statementFileName)
        {
            _statementFileName = statementFileName;

            _service.SendStatementEmails(_statementDate);

            VerifyEmailNotSent();
        }

        [Test]
        public void SendStatementEmails_EmailSendingFails_DisplayAMessageBox()
        {
            _emailSender
                .Setup(es => es.EmailFile(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>()))
                .Throws<Exception>();

            _service.SendStatementEmails(_statementDate);

            _messageBox.Verify(mb => mb.Show(It.IsAny<string>(), It.IsAny<string>(), MessageBoxButtons.OK), Times.Once);
        }

        private void VerifyEmailNotSent()
        {
            _emailSender.Verify(
                es => es.EmailFile(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>()),
                Times.Never);
        }
    }
}