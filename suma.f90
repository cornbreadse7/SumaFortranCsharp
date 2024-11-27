! archivo: suma.f90
module suma_module
    implicit none
  contains
    function suma(a, b) bind(c, name="suma")
      real(8), intent(in) :: a, b
      real(8) :: suma
  
      suma = a + b
    end function suma
  end module suma_module
  