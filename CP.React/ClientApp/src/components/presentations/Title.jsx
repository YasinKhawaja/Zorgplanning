import { Box } from "@mui/material";

export default function Title({ primary, secondary }) {
  return (
    <Box sx={{ textAlign: "center", marginBottom: 5 }}>
      <h1>{primary}</h1>
      <p>{secondary}</p>
    </Box>
  );
}
