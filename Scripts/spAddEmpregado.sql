Create procedure spAddEmpregado         
(        
    @Nome VARCHAR(250),        
    @SalarioBruto DECIMAL(18,2),        
    @SalarioLiquido DECIMAL(18,2),        
    @FaixaImposto VARCHAR(20)

)        
as         
Begin         
    Insert into tblEmployee (Nome,SalarioBruto,SalarioLiquido,FaixaImposto)         
    Values (@Nome,@SalarioBruto,@SalarioLiquido, @FaixaImposto)         
End    