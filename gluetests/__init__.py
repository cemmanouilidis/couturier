from PDFUtilTests import PDFUtilTests


def get_unittests ():
    return [PDFUtilTests, ]


def run_tests():
    test_was_successful = True 

    testcases = get_unittests()
    if testcases is not None:
        import unittest
        for case in testcases:
            suite = unittest.TestLoader().loadTestsFromTestCase(case)
            result = unittest.TextTestRunner(verbosity=2).run(suite)
            
            if not result.wasSuccessful():
                test_was_successful = False
                break

    return test_was_successful

