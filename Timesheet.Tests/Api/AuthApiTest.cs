using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RestAssured.Dsl;
using System.Net;

namespace Timesheet.Test.Api;



    public class AuthAPITest
    {

        [Test]
        public void TestLoginReturnsPositiveResponse()
        {
            Login login = new("admin@test.com", "password123");

            HttpResponseMessage response = Given()
                                .Body(login)
                                .ContentType("application/json")
                                .Post("http://localhost:8080/v1/auth/login")
                                .Then()
                                .Extract()
                                .Response();

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

    }

