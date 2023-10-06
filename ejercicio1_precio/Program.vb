Imports System

Module Program
    ' Función para calcular el cambio
    Function CalcularCambio(precio As Double, pago As Double) As Double
        If pago >= precio Then
            Return pago - precio
        Else
            Return -1 ' Valor especial para indicar que el pago es insuficiente
        End If
    End Function

    Sub ProcesarCompra()
        Console.Write("Ingrese el costo del artículo: ")
        Dim precio As Double = Double.Parse(Console.ReadLine())
        Console.Write("Ingrese la cantidad de dinero entregada por el cliente: ")
        Dim pagoCliente As Double = Double.Parse(Console.ReadLine())

        Dim cambio As Double = CalcularCambio(precio, pagoCliente)

        If cambio = 0 Then
            Console.WriteLine("El cliente ha pagado exactamente el precio del producto. Entregando el producto.")
            Console.WriteLine("Producto entregado.")
        ElseIf cambio > 0 Then
            Console.WriteLine($"El cambio a entregar al cliente es: ${cambio}")
            Console.WriteLine("Producto entregado.")
        Else
            Console.WriteLine("El pago es insuficiente. Falta dinero por pagar.")

            ' Solicitar la cantidad que falta
            Dim cantidadFaltante As Double = precio - pagoCliente
            Console.Write($"Ingrese la cantidad que falta (${cantidadFaltante:F2}) o 'n' para cancelar: ")
            Dim opcion As String = Console.ReadLine().Trim().ToLower()

            If opcion = "n" Then
                Console.WriteLine("Compra cancelada. Producto no entregado.")
            Else
                ' Convertir la entrada a un número
                If Double.TryParse(opcion, cantidadFaltante) AndAlso cantidadFaltante > 0 Then
                    ' Calcular el nuevo cambio
                    cambio = CalcularCambio(precio, pagoCliente + cantidadFaltante)

                    If cambio >= 0 Then
                        Console.WriteLine($"Se han agregado ${cantidadFaltante:F2}. El cambio a entregar al cliente es: ${cambio}")
                        Console.WriteLine("Producto entregado.")
                    Else
                        Console.WriteLine("El pago sigue siendo insuficiente. Compra cancelada. Producto no entregado.")
                    End If
                Else
                    Console.WriteLine("Entrada inválida. Compra cancelada. Producto no entregado.")
                End If
            End If
        End If
    End Sub

    Sub Main(args As String())
        Do
            ProcesarCompra()
            Console.Write("¿Desea realizar otra compra? (S/N): ")
            Dim continuar As String = Console.ReadLine().Trim().ToLower()
            If continuar <> "s" Then
                Exit Do
            End If
        Loop While True

        Console.WriteLine("Gracias por su compra. ¡Vuelva pronto!")
        Console.WriteLine("Creadores: Hugo Nelson Ramirez Perez y Francisco Salvador Moreno Garcia ")
    End Sub
End Module
