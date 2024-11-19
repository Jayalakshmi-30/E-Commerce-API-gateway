using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Any;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ECommerceGateway.Filters
{
    public class SwaggerDocumentFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            swaggerDoc.Paths.Clear();

            // User Endpoints
            AddUserEndpoints(swaggerDoc);

            // Product Endpoints
            AddProductEndpoints(swaggerDoc);
            AddCategoryEndpoints(swaggerDoc);
        }

        private void AddUserEndpoints(OpenApiDocument swaggerDoc)
        {
            // User Login
            swaggerDoc.Paths.Add("/user/login", new OpenApiPathItem
            {
                Operations = new Dictionary<OperationType, OpenApiOperation>
                {
                    [OperationType.Post] = new OpenApiOperation
                    {
                        Tags = new List<OpenApiTag> { new OpenApiTag { Name = "User" } },
                        Summary = "User Login",
                        RequestBody = new OpenApiRequestBody
                        {
                            Required = true,
                            Content = new Dictionary<string, OpenApiMediaType>
                            {
                                ["application/json"] = new OpenApiMediaType
                                {
                                    Schema = new OpenApiSchema
                                    {
                                        Type = "object",
                                        Properties = new Dictionary<string, OpenApiSchema>
                                        {
                                            ["email"] = new OpenApiSchema { Type = "string", Format = "email" },
                                            ["password"] = new OpenApiSchema { Type = "string" }
                                        },
                                        Example = new OpenApiObject
                                        {
                                            ["email"] = new OpenApiString("john.doe@example.com"),
                                            ["password"] = new OpenApiString("Test@123")
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            });

            // User CRUD Operations
            swaggerDoc.Paths.Add("/user", new OpenApiPathItem
            {
                Operations = new Dictionary<OperationType, OpenApiOperation>
                {
                    [OperationType.Post] = new OpenApiOperation
                    {
                        Tags = new List<OpenApiTag> { new OpenApiTag { Name = "User" } },
                        Summary = "Create User",
                        RequestBody = new OpenApiRequestBody
                        {
                            Required = true,
                            Content = new Dictionary<string, OpenApiMediaType>
                            {
                                ["application/json"] = new OpenApiMediaType
                                {
                                    Schema = new OpenApiSchema
                                    {
                                        Type = "object",
                                        Properties = new Dictionary<string, OpenApiSchema>
                                        {
                                            ["firstName"] = new OpenApiSchema { Type = "string" },
                                            ["lastName"] = new OpenApiSchema { Type = "string" },
                                            ["email"] = new OpenApiSchema { Type = "string", Format = "email" },
                                            ["password"] = new OpenApiSchema { Type = "string" },
                                            ["phone"] = new OpenApiSchema { Type = "integer" },
                                            ["role"] = new OpenApiSchema { Type = "string" },
                                            ["address"] = new OpenApiSchema
                                            {
                                                Type = "array",
                                                Items = new OpenApiSchema
                                                {
                                                    Type = "object",
                                                    Properties = new Dictionary<string, OpenApiSchema>
                                                    {
                                                        ["name"] = new OpenApiSchema { Type = "string" },
                                                        ["type"] = new OpenApiSchema { Type = "string" },
                                                        ["phone"] = new OpenApiSchema { Type = "integer" },
                                                        ["line1"] = new OpenApiSchema { Type = "string" },
                                                        ["line2"] = new OpenApiSchema { Type = "string" },
                                                        ["city"] = new OpenApiSchema { Type = "string" },
                                                        ["pincode"] = new OpenApiSchema { Type = "integer" },
                                                        ["state"] = new OpenApiSchema { Type = "string" },
                                                        ["country"] = new OpenApiSchema { Type = "string" }
                                                    }
                                                }
                                            }
                                        },
                                        Example = new OpenApiObject
                                        {
                                            ["firstName"] = new OpenApiString("John"),
                                            ["lastName"] = new OpenApiString("Doe"),
                                            ["email"] = new OpenApiString("john.doe@example.com"),
                                            ["password"] = new OpenApiString("Test@123"),
                                            ["phone"] = new OpenApiInteger(1234567890),
                                            ["role"] = new OpenApiString("user"),
                                            ["address"] = new OpenApiArray
                                            {
                                                new OpenApiObject
                                                {
                                                    ["name"] = new OpenApiString("Home"),
                                                    ["type"] = new OpenApiString("residential"),
                                                    ["phone"] = new OpenApiInteger(1234567890),
                                                    ["line1"] = new OpenApiString("123 Main St"),
                                                    ["line2"] = new OpenApiString("Apt 4B"),
                                                    ["city"] = new OpenApiString("Bangalore"),
                                                    ["pincode"] = new OpenApiInteger(560001),
                                                    ["state"] = new OpenApiString("Karnataka"),
                                                    ["country"] = new OpenApiString("India")
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    },
                    [OperationType.Get] = new OpenApiOperation
                    {
                        Tags = new List<OpenApiTag> { new OpenApiTag { Name = "User" } },
                        Summary = "Get All Users"
                    }
                }
            });
        }

        private void AddProductEndpoints(OpenApiDocument swaggerDoc)
        {
            swaggerDoc.Paths.Add("/products", new OpenApiPathItem
            {
                Operations = new Dictionary<OperationType, OpenApiOperation>
                {
                    [OperationType.Post] = new OpenApiOperation
                    {
                        Tags = new List<OpenApiTag> { new OpenApiTag { Name = "Products" } },
                        Summary = "Create Product",
                        RequestBody = new OpenApiRequestBody
                        {
                            Required = true,
                            Content = new Dictionary<string, OpenApiMediaType>
                            {
                                ["application/json"] = new OpenApiMediaType
                                {
                                    Schema = new OpenApiSchema
                                    {
                                        Type = "object",
                                        Properties = new Dictionary<string, OpenApiSchema>
                                        {
                                            ["name"] = new OpenApiSchema { Type = "string" },
                                            ["description"] = new OpenApiSchema { Type = "string" },
                                            ["price"] = new OpenApiSchema { Type = "number" },
                                            ["categoryId"] = new OpenApiSchema { Type = "string" }
                                        },
                                        Example = new OpenApiObject
                                        {
                                            ["name"] = new OpenApiString("Sample Product"),
                                            ["description"] = new OpenApiString("Product Description"),
                                            ["price"] = new OpenApiDouble(99.99),
                                            ["categoryId"] = new OpenApiString("category123")
                                        }
                                    }
                                }
                            }
                        }
                    },
                    [OperationType.Get] = new OpenApiOperation
                    {
                        Tags = new List<OpenApiTag> { new OpenApiTag { Name = "Products" } },
                        Summary = "Get All Products"
                    }
                }
            });
        }

        private void AddCategoryEndpoints(OpenApiDocument swaggerDoc)
        {
            swaggerDoc.Paths.Add("/categories", new OpenApiPathItem
            {
                Operations = new Dictionary<OperationType, OpenApiOperation>
                {
                    [OperationType.Post] = new OpenApiOperation
                    {
                        Tags = new List<OpenApiTag> { new OpenApiTag { Name = "Categories" } },
                        Summary = "Create Category",
                        RequestBody = new OpenApiRequestBody
                        {
                            Required = true,
                            Content = new Dictionary<string, OpenApiMediaType>
                            {
                                ["application/json"] = new OpenApiMediaType
                                {
                                    Schema = new OpenApiSchema
                                    {
                                        Type = "object",
                                        Properties = new Dictionary<string, OpenApiSchema>
                                        {
                                            ["name"] = new OpenApiSchema { Type = "string" },
                                            ["description"] = new OpenApiSchema { Type = "string" }
                                        },
                                        Example = new OpenApiObject
                                        {
                                            ["name"] = new OpenApiString("Electronics"),
                                            ["description"] = new OpenApiString("Electronic Products Category")
                                        }
                                    }
                                }
                            }
                        }
                    },
                    [OperationType.Get] = new OpenApiOperation
                    {
                        Tags = new List<OpenApiTag> { new OpenApiTag { Name = "Categories" } },
                        Summary = "Get All Categories"
                    }
                }
            });
        }
    }
}
