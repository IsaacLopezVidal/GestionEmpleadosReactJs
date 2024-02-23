import { useState, useEffect } from 'react';
function Select({  name, onChange ,urlRequest}) {
    const [options, setOptions] = useState([]);
    useEffect(() => {
        getDatos()
    },[])
    async function getDatos() {
        const response = await fetch(urlRequest);
        const data = await response.json();
        setOptions(data);
    }
    const fnOnChange = function (e) {
        const selectedValue = e.target.value;
        onChange(name, selectedValue);
    }
    return (
        <select name={name} onChange={fnOnChange} >
            <option> SECCIONE </option>
            {options.length 
                ? options.map((i) => (
                    <option key={i.id} value={i.id}>
                        {i.descripcion}
                    </option>
                ))
                : <option>SIN ELEMENTOS</option>}
        </select>
    );
}

export default Select;
