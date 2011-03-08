#!/usr/bin/env python

import os
import sys
sys.path.append("..")

from unittest import TestCase
from glue.pdf import PDFUtil

class PDFUtilTests(TestCase):

    def setUp (self):
        self.pdfutil = PDFUtil()
        self.assertTrue((self.pdfutil is not None), "Could not create pdfutil object")
        
    def testConvertPNGToPDF (self):
        image  = "data/todo.png"
        output = "data/todo.pdf"
    
        if os.path.exists(output):
            os.remove(output)

        transformed, error = self.pdfutil.ConvertToPDF(image, output)

        self.assertTrue (transformed, "Could not transform PNG to PDF: %s" % error)


if __name__ == "__main__":
    unittest.main()
