# Phony
Generate test data for your classes. 

#Basic usage

        var generator = new DataGenerator<SampleTestClass>(cfg =>
        {
            cfg.Setup(x => x.IntegerProp, integerValue);
            cfg.Setup(x => x.StringProp, () => SomeFunctionReturningAString());
            cfg.Setup(x => x.ComplexProp, someComplexInstance);
        });
