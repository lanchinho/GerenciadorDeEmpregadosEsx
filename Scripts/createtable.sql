Create table Empregado(      
    Id int IDENTITY(1,1) NOT NULL,      
    Nome nvarchar(250) NOT NULL,    
    SalarioBruto decimal(18,2) NOT NULL,      
	SalarioLiquido decimal(18,2) NOT NULL,    
	FaixaImposto decimal(3,2) NOT NULL
)