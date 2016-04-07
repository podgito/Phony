# Phony
Generate test data for your classes. 

#Basic usage

        //Setup the generator with rules for each class property
        var generator = new PhonyGenerator<SampleTestClass>(cfg =>
        {
            cfg.Setup(x => x.IntegerProp, integerValue);
            cfg.Setup(x => x.StringProp, () => SomeFunctionReturningAString());
            cfg.Setup(x => x.ComplexProp, someComplexInstance);
        });
        
        //Creates 100 instances of SampleTestClass
        var items = generator.Generate(100); 
