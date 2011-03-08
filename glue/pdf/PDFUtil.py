import os

class PDFUtil:
    def __init__(self):
        pass

    def ConvertToPDF(self, input, output):
        succeded = False
        error    = ""

        if os.path.exists(input):
            cmd = "convert %s %s" % (input, output)
            convert_output = os.popen(cmd).read()

            os.system(cmd)
            if os.path.exists(output):
                succeded = True
            else:
                succeded = False
                error = convert_output

        else:
            succeded = False
            error = "input file %s does not exist" % input

        return succeded, error

class PDFInfoPoppler(object):
    def __init__(self):
        pass

    def GetNumberOfPages (self, pdffile):
        nrofpages = 0
        cmd = 'pdfinfo "%s" | grep -i pages' % pdffile
        
        popplerout = os.popen(cmd).read()
        try:
            nrofpages = int(popplerout.split(":")[1].strip())
        except Exception, e:
            print "Failed to get nuber of pages from pdf file:%s" % e
            nrofpages = 0

        return nrofpages

if __name__ == "__main__":
    pdffile = "/home/babi/Dokumente/Bewerbung/Master/Master/Upload UCL/Application Completed.pdf"
    
    popplerinfo = PDFInfoPoppler()
    nrofpages = popplerinfo.GetNumberOfPages(pdffile)

    print "PDF Document %s has %d number of pages" % (pdffile, nrofpages)
