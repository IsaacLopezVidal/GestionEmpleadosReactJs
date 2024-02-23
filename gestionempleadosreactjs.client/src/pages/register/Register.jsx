import { useState , useEffect } from 'react';
import Select from '../../components/select/Select'
import axios from 'axios'
const Register = () => {
    const [formData, setFormData] = useState({
        emailAddress: "",
        password: "",
        idCargo: 0,
        idDepartamento: 0,
        lastName: "",
        firstName: ""
    });
    const [newUser, setNewUser] = useState(false)
    useEffect(() => {
        if (newUser) {
            setFormData({
                ...formData,
                emailAddress: "",
                password: "",
                idCargo: 0,
                idDepartamento: 0,
                lastName: "",
                firstName: ""
            })
        }
    }, [newUser])
    const handleInputChange = (e) => {
        const { name, value } = e.target;
        setFormData({
            ...formData,
            [name]: value,
        });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            console.log('Datos del formulario:', formData);
            const response = await axios.post('auth/register', formData)
            console.log({ response })
            setNewUser(true)
        } catch (e) {
            console.error(e)
        }
    };
    const handleSelectChange = (name, selectedValue) => {
        setFormData({
            ...formData,
            [name]: selectedValue,
        });
    };
    return (
        <form onSubmit={handleSubmit}>
            <input type="text" placeholder="Nombre" name="firstName" value={formData.firstName} onChange={handleInputChange} />
            <input type="text" placeholder="Apellido" name="lastName" value={formData.lastName} onChange={handleInputChange} />
            <input type="email" placeholder="Correo" name="emailAddress" value={formData.emailAddress} onChange={handleInputChange} />
            <input type="password" placeholder="Contraseña" name="password" value={formData.password} onChange={handleInputChange} />
            <Select name="idCargo" onChange={handleSelectChange} urlRequest="auth/GetCargos" />
            <Select name="idDepartamento" onChange={handleSelectChange} urlRequest="auth/GetDepartamentos" />
            <button type="submit">Registrarse</button>
            {newUser ? <h1>Bienvenido {formData.firstName} {formData.lastName}</h1>:<></>}
        </form>
    );
};

export default Register;