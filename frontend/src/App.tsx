import React from 'react';
import './App.css';
import { Cliente } from "./components/Cliente";
import { Producto } from "./components/Producto";
import { OrdenTrabajo } from "./components/OrdenTrabajo";
import Tabs from "@mui/material/Tabs";
import Tab from "@mui/material/Tab";
import Typography from "@mui/material/Typography";
import Box from "@mui/material/Box";

interface TabPanelProps {
  children?: React.ReactNode;
  index: number;
  value: number;
}

function TabPanel(props: TabPanelProps) {
  const { children, value, index, ...other } = props;

  return (
    <div
      role="tabpanel"
      hidden={value !== index}
      id={`simple-tabpanel-${index}`}
      aria-labelledby={`simple-tab-${index}`}
      {...other}
    >
      {value === index && (
        <Box sx={{ p: 3 }}>
          <div>{children}</div>
        </Box>
      )}
    </div>
  );
}

function a11yProps(index: number) {
  return {
    id: `simple-tab-${index}`,
    "aria-controls": `simple-tabpanel-${index}`,
  };
}


function App() {
  const [value, setValue] = React.useState(0);

  const handleChange = (event: React.SyntheticEvent, newValue: number) => {
    setValue(newValue);
  };

  return (
    <>
      <Box sx={{ borderBottom: 1, borderColor: "divider" }}>
        <Tabs
          value={value}
          onChange={handleChange}
          aria-label="basic tabs example"
        >
          <Tab label="Clientes" {...a11yProps(0)} />
          <Tab label="Productos" {...a11yProps(1)} />
          <Tab label="Ordenes de Trabajo" {...a11yProps(2)} />
        </Tabs>
      </Box>
      <TabPanel value={value} index={0}>
        Clientes
         <Cliente />
      </TabPanel>
      <TabPanel value={value} index={1}>
        Productos
          <Producto />
      </TabPanel>
      <TabPanel value={value} index={2}>
        
        <OrdenTrabajo />
      </TabPanel>
    </>
  );
}

export default App;
