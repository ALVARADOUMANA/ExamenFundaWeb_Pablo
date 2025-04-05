import React, { useState, useEffect, useRef } from 'react';
import { 
  Navbar, 
  Nav, 
  NavItem
} from 'reactstrap';
import { 
  User,
  Clock,
  Mail
} from 'react-feather';

const MyNavbar = () => {
  const [currentTime, setCurrentTime] = useState('');
  const [currentDate, setCurrentDate] = useState('');
  const [userDropdownOpen, setUserDropdownOpen] = useState(false);
  const dropdownRef = useRef(null);

  // Cerrar el dropdown cuando se hace clic fuera de él
  useEffect(() => {
    function handleClickOutside(event) {
      if (dropdownRef.current && !dropdownRef.current.contains(event.target)) {
        setUserDropdownOpen(false);
      }
    }

    document.addEventListener("mousedown", handleClickOutside);
    return () => {
      document.removeEventListener("mousedown", handleClickOutside);
    };
  }, [dropdownRef]);

  // Actualizar la hora y fecha
  useEffect(() => {
    const updateDateTime = () => {
      const now = new Date();
      setCurrentTime(now.toLocaleTimeString('es-ES'));
      
      // Formato de fecha: día de la semana, día de mes de año
      const options = { weekday: 'long', year: 'numeric', month: 'long', day: 'numeric' };
      setCurrentDate(now.toLocaleDateString('es-ES', options));
    };
    
    updateDateTime();
    const interval = setInterval(updateDateTime, 1000);
    return () => clearInterval(interval);
  }, []);

  return (
    <Navbar 
      dark
      expand="md" 
      className="py-2 px-4" 
      style={{ 
        backgroundColor: '#1E3A23',
        boxShadow: '0 2px 8px rgba(0,0,0,0.12)'
      }}
    >
      <div className="d-flex justify-content-between align-items-center w-100">
        {/* Parte izquierda - Reloj y Fecha */}
        <div className="d-flex flex-column align-items-start text-white">
          <div className="d-flex align-items-center">
            <Clock size={18} className="me-2" />
            <span className="fw-bold" style={{ fontSize: '1.1rem' }}>{currentTime}</span>
          </div>
          <div style={{ fontSize: '0.8rem', opacity: 0.9, textTransform: 'capitalize' }}>
            {currentDate}
          </div>
        </div>

        {/* Parte central vacía para mantener el equilibrio */}
        <div className="d-none d-lg-flex"></div>

        {/* Parte derecha - Perfil de usuario */}
        <Nav className="ml-auto" navbar>
          {/* Perfil de usuario - Implementación personalizada del dropdown */}
          <NavItem className="ms-2 d-flex align-items-center">
            <div ref={dropdownRef} className="position-relative">
              {/* Toggle button */}
              <div 
                onClick={() => setUserDropdownOpen(!userDropdownOpen)}
                style={{ cursor: 'pointer' }}
              >
                <div className="d-flex align-items-center">
                  <div 
                    className="rounded-circle bg-white text-dark d-flex justify-content-center align-items-center me-2"
                    style={{ 
                      width: '40px', 
                      height: '40px',
                      boxShadow: '0 2px 5px rgba(0,0,0,0.1)'
                    }}
                  >
                    <span className="fw-bold">PAU</span>
                  </div>
                  <div className="d-none d-md-block text-white">
                    <div className="fw-bold" style={{ fontSize: '0.95rem' }}>Pablo Alvarado Umaña</div>
                    <div style={{ fontSize: '0.8rem', opacity: 0.8 }}>Estudiante</div>
                  </div>
                </div>
              </div>
              
              {/* Dropdown menu - implementación personalizada en lugar de usar DropdownMenu */}
              {userDropdownOpen && (
                <div 
                  className="position-absolute bg-white rounded shadow"
                  style={{ 
                    minWidth: '250px', 
                    padding: '0.5rem 0',
                    marginTop: '0.5rem',
                    zIndex: 1050,
                    top: '100%',
                    right: 0,
                    position: 'fixed', // Mantiene el menú visible al hacer scroll
                    transform: 'translateX(10%)'  // Ajusta la posición horizontal
                  }}
                >
                  <div className="px-3 py-2 mb-2">
                    <div className="d-flex align-items-center">
                      <div 
                        className="rounded-circle bg-light d-flex justify-content-center align-items-center me-3"
                        style={{ width: '48px', height: '48px' }}>
                        <User size={24} />
                      </div>
                      <div>
                        <div className="fw-bold">Pablo Alvarado Umaña</div>
                        <div className="text-muted d-flex align-items-center" style={{ fontSize: '0.85rem' }}>
                          <Mail size={14} className="me-1" /> pablo.alvarado.umana@est.una.ac.cr
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              )}
            </div>
          </NavItem>
        </Nav>
      </div>
    </Navbar>
  );
};

export default MyNavbar;