import  { useState} from 'react';
import axios from 'axios';

const Login = () => {
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
    
    const handleLogin = async () => {
        try {
            const response = await axios.post('Auth/login', {
                username: username,
                password: password
            });
            const token = response.data.token;
            // Almacena el token en el estado o localStorage según tu preferencia
        } catch (error) {
            console.error('Error de inicio de sesión:', error);
        }
    };

    return (
        <div>
            <input type="text" placeholder="Nombre de usuario" onChange={(e) => setUsername(e.target.value)} />
            <input type="password" placeholder="Contraseña" onChange={(e) => setPassword(e.target.value)} />
            <button onClick={handleLogin}>Iniciar sesión</button>
        </div>
    );
};

export default Login;
