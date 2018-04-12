Create procedure spAddEmpregado         
(        
    @Nome NVARCHAR(250),        
    @SalarioBruto DECIMAL(18,2),        
    @SalarioLiquido DECIMAL(18,2),        
    @FaixaImposto DECIMAL(3,2)

)        
as         
Begin         
    Insert into tblEmployee (Nome,SalarioBruto,SalarioLiquido,FaixaImposto)         
    Values (@Nome,@SalarioBruto,@SalarioLiquido, @FaixaImposto)         
End    