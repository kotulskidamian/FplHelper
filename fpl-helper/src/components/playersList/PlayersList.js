import React from 'react';
import PropTypes from 'prop-types';
import Box from '@mui/material/Box';
import { DataGrid } from '@mui/x-data-grid';

const PAGE_SIZE = 30;

const getFullName = (params) => `${params.row?.first_name || ''} ${params.row?.second_name || ''}`;

const createColumn = (field, headerName, type, width, editable, valueGetter = null) => {
  let column = {
    field,
    headerName,
    type,
    width,
    editable,
    align: 'center',
    headerAlign: 'center',
  };

  if (valueGetter) {
    column = {
      ...column,
      valueGetter,
    };
  }

  return column;
};

const columns = [
  createColumn('name', 'Name', 'string', 300, false, getFullName),
  createColumn('total_points', 'Total points', 'number', 150, false),
  createColumn('value_season', 'Value', 'string', 150, false),
  createColumn('now_cost', 'Cost', 'number', 150, false),
];

const PlayersList = ({ type, players }) => (
  <>
    {type}
    <Box sx={{ height: 500, width: '100%' }}>
      <DataGrid
        rows={players}
        columns={columns}
        pageSize={PAGE_SIZE}
        rowsPerPageOptions={[PAGE_SIZE]}
        getRowId={(player) => player.id}
        disableColumnMenu
      />
    </Box>
  </>
);

PlayersList.propTypes = {
  type: PropTypes.string.isRequired,
  players: PropTypes.arrayOf(
    PropTypes.shape({
      first_name: PropTypes.string.isRequired,
      second_name: PropTypes.string.isRequired,
      total_points: PropTypes.number.isRequired,
      value_season: PropTypes.string.isRequired,
      now_cost: PropTypes.number.isRequired,
    }),
  ).isRequired,
};

export default PlayersList;
