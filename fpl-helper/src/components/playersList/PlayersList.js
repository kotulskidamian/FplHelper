import React from 'react';
import PropTypes from 'prop-types';
import Box from '@mui/material/Box';
import { DataGrid } from '@mui/x-data-grid';

const PAGE_SIZE = 30;

const getFullName = params => `${params.row?.firstName || ''} ${params.row?.secondName || ''}`;

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
  createColumn('selectedByPercent', 'Selected %', 'string', 100, false),
  createColumn('cost', 'Cost', 'number', 100, false),
  createColumn('totalPoints', 'Total points', 'number', 100, false),
  createColumn('expectedGoals', 'Expected goals', 'string', 100, false),
  createColumn('expectedAssists', 'Expected assists', 'string', 100, false),
  createColumn('valueSeason', 'Value', 'string', 100, false),
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
        getRowId={player => player.playerId}
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
