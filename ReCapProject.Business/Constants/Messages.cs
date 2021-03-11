using ReCapProject.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ReCapProject.Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Car added successfuly";
        public  static string MaintenanceTime = "Maintenance time";
        public  static string CarsListed = "Cars listed";
        public static string CarDeleted = "Car deleted successfuly";
        public static string CarModified = "Car modified successfuly";
        public static string Carnotreturn = "Car not return yet";

        public static string BrandAdded = "Brand added successfuly";
        public static string BrandsListed = "Brands listed";
        public static string BrandDeleted = "Brand deleted successfuly";
        public static string BrandModified = "Brand modified successfuly";


        public static string ColorAdded = "Color added successfuly";
        public static string ColorsListed = "Colors listed";
        public static string ColorDeleted = "Color deleted successfuly";
        public static string ColorModified = "Color modified successfuly";

        public static string CustomerAdded = "Customer added successfuly";
        public static string CustomersListed = "Customers listed";
        public static string CustomerDeleted = "Customer deleted successfuly";
        public static string CustomerModified = "Customer modified successfuly";

        public static string RentalAdded = "Rental added successfuly";
        public static string RentalsListed = "Rentals listed";
        public static string RentalDeleted = "Rental deleted successfuly";
        public static string RentalModified = "Rental modified successfuly";

        public static string UserAdded = "User added successfuly";
        public static string UsersListed = "Users listed";
        public static string UserDeleted = "User deleted successfuly";
        public static string UserModified = "User modified successfuly";

        public static string CarImageAdded = "Car Image added successfuly";
        public static string CarImageListed = "Car Images listed";
        public static string CarImageDeleted = "Car Image deleted successfuly";
        public static string CarImageModified = "Car Image modified successfuly";

        public static string CarImageLimitExceeded = "Car can not have more than 5 pictures";
        public static string AuthorizationDenied= "Authorization Denied";
        public static string UserRegistered= "User registered successfuly";
        public static string UserNotFound= "User Not Found";
        public static string PasswordError= "Wrong Password ";
        public static string SuccessfulLogin= "Successful Login ";
        public static string UserAlreadyExists = " User Already Exists";
        public static string AccessTokenCreated= "Token Created ";
    }
}
