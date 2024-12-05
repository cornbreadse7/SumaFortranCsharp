! archivo: suma.f90
module suma_module
  use, intrinsic :: iso_c_binding
  implicit none
contains
  function suma(a, b) bind(c, name="suma")
      real(c_double), value, intent(in) :: a, b  ! Add value attribute
      real(c_double) :: suma
      
      suma = a + b
  end function suma
end module suma_module