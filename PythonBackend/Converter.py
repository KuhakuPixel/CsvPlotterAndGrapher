class Converter:
    @staticmethod
    def convert_array_in_string_to_array(arrayString: str)->list:
        arrayString=arrayString.replace("[", "")
        arrayString=arrayString.replace("]", "")
        arrayString = arrayString.split(sep=",")

        array = []
        for i in range(0,len(arrayString)):
            num = int(arrayString[i])
            array.append(num)

        return array