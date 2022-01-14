create procedure AddPayrollServices	
(
 @Name varchar(50),
 @Basic_pay float,
 @StartDate Date,
 @gender char(1),
 @phone bigint,
 @Address varchar(200),
 @Department varchar(200),
 @Deduction bigint,
 @Taxable_pay float,
 @IncomeTax_pay float,
 @Net_Pay float,
 @DepId int
)
as
begin try
     insert into employee_payroll values ( @Name, @Basic_pay ,@StartDate,@gender, @phone,  @Address,@Department, @Deduction, @Taxable_pay, @IncomeTax_pay,@Net_Pay,@DepId )
	 
end try
begin catch
select
ERROR_NUMBER() as ErrorNumber,
ERROR_STATE() as ErrorState,
ERROR_PROCEDURE() as ErrorProcedure,
ERROR_LINE() as ErrorLine,
ERROR_MESSAGE() as ErrorMassage;
End catch



create procedure DeletePayrollServices	
(
 @id int
)
as
begin try
     Delete from employee_payroll where id = @id
	 
end try
begin catch
select
ERROR_NUMBER() as ErrorNumber,
ERROR_STATE() as ErrorState,
ERROR_PROCEDURE() as ErrorProcedure,
ERROR_LINE() as ErrorLine,
ERROR_MESSAGE() as ErrorMassage;
End catch

select * from employee_payroll

exec DeletePayrollServices 1


create procedure GetPayrollServices	
(
 @id int
)
as
begin try
     
	 select * from employee_payroll
end try
begin catch
select
ERROR_NUMBER() as ErrorNumber,
ERROR_STATE() as ErrorState,
ERROR_PROCEDURE() as ErrorProcedure,
ERROR_LINE() as ErrorLine,
ERROR_MESSAGE() as ErrorMassage;
End catch


create procedure UpdatePayrollServices	
(
 @Name varchar(50),
 @Basic_pay float,
 @StartDate Date,
 @gender char(1),
 @phone bigint,
 @Address varchar(200),
 @Department varchar(200),
 @Deduction bigint,
 @Taxable_pay float,
 @IncomeTax_pay float,
 @Net_Pay float,
 @DepId int
)
as
begin try
     update employee_payroll set Name=@Name, BasicPay= @Basic_pay ,StartDate = @StartDate, Gender=@gender,phone= @phone,Address=@Address,Department=@Department,Deduction=@Deduction,Taxablepay=@Taxable_pay,IncomeTax_pay= @IncomeTax_pay,NetPay=@Net_Pay,DepId=@DepId where id= @id
	 
end try
begin catch
select
ERROR_NUMBER() as ErrorNumber,
ERROR_STATE() as ErrorState,
ERROR_PROCEDURE() as ErrorProcedure,
ERROR_LINE() as ErrorLine,
ERROR_MESSAGE() as ErrorMassage;
End catch