import React, { useState, useEffect, useCallback } from 'react';
import {
  Container,
  Typography,
  Button,
  LinearProgress,
  Box,
  Grid,
  CircularProgress,
  Alert,
  Paper
} from '@mui/material';
import { useParams } from 'react-router-dom';
import { getValeraById, performAction } from '../services/api';

export default function ValeraStats() {
  const [valera, setValera] = useState(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);
  const [actionLoading, setActionLoading] = useState(null);

  const { id } = useParams();

  // Оборачиваем в useCallback, чтобы функция не пересоздавалась
  const loadValera = useCallback(async () => {
    if (!id) return;
    try {
      setLoading(true);
      setError(null);
      const response = await getValeraById(id);
      setValera(response.data);
    } catch (err) {
      setError('Валера не найден или backend недоступен');
      console.error(err);
    } finally {
      setLoading(false);
    }
  }, [id]); // ← зависимость только от id

  useEffect(() => {
    loadValera();
  }, [id, loadValera]);

  const handleAction = async (action) => {
    setActionLoading(action);
    try {
      await performAction(id, action);
      await loadValera(); // обновляем данные
    } catch (err) {
      alert(`Ошибка при выполнении "${action}"`);
      console.error(err);
    } finally {
      setActionLoading(null);
    }
  };

  if (loading) {
    return (
      <Box sx={{ display: 'flex', justifyContent: 'center', mt: 4 }}>
        <CircularProgress />
      </Box>
    );
  }

  if (error || !valera) {
    return (
      <Container maxWidth="sm" sx={{ mt: 4 }}>
        <Alert severity="error">{error}</Alert>
      </Container>
    );
  }

  return (
    <Container maxWidth="md" sx={{ py: 4 }}>
      <Typography variant="h3" align="center" gutterBottom>
        {valera.name}
      </Typography>

      <Paper elevation={3} sx={{ p: 3, mb: 4 }}>
        <Grid container spacing={3}>
          {/* Здоровье */}
          <Grid item xs={12}>
            <Typography>❤️ Здоровье: {valera.health}/100</Typography>
            <LinearProgress
              variant="determinate"
              value={valera.health}
              sx={{ 
                height: 10, 
                borderRadius: 5,
                bgcolor: '#e0e0e0',
                '& .MuiLinearProgress-bar': { 
                  bgcolor: valera.health > 70 ? '#4caf50' : valera.health > 30 ? '#ff9800' : '#f44336' 
                }
              }}
            />
          </Grid>

          {/* Алкоголь */}
          <Grid item xs={12}>
            <Typography>🍷 Алкоголь: {valera.alcohol}/100</Typography>
            <LinearProgress
              variant="determinate"
              value={valera.alcohol}
              sx={{ 
                height: 10, 
                borderRadius: 5,
                bgcolor: '#e0e0e0',
                '& .MuiLinearProgress-bar': { 
                  bgcolor: valera.alcohol > 70 ? '#f44336' : valera.alcohol > 30 ? '#ff9800' : '#4caf50' 
                }
              }}
            />
          </Grid>

          {/* Усталость */}
          <Grid item xs={12}>
            <Typography>😴 Усталость: {valera.fatigue}/100</Typography>
            <LinearProgress
              variant="determinate"
              value={valera.fatigue}
              sx={{ 
                height: 10, 
                borderRadius: 5,
                bgcolor: '#e0e0e0',
                '& .MuiLinearProgress-bar': { 
                  bgcolor: valera.fatigue > 70 ? '#f44336' : valera.fatigue > 30 ? '#ff9800' : '#4caf50' 
                }
              }}
            />
          </Grid>

          {/* Жизнерадостность */}
          <Grid item xs={12}>
            <Typography>😊 Жизнерадостность: {valera.joy}/10</Typography>
            <LinearProgress
              variant="determinate"
              value={Math.max(0, ((valera.joy + 10) / 20) * 100)}
              sx={{ 
                height: 10, 
                borderRadius: 5,
                bgcolor: '#e0e0e0',
                '& .MuiLinearProgress-bar': { 
                  bgcolor: valera.joy > 0 ? '#4caf50' : '#ff9800' 
                }
              }}
            />
          </Grid>

          {/* Деньги */}
          <Grid item xs={12}>
            <Typography variant="h5">💰 Деньги: ${valera.money}</Typography>
          </Grid>
        </Grid>
      </Paper>

      {/* Панель действий */}
      <Typography variant="h5" gutterBottom>Действия</Typography>
      <Grid container spacing={2}>
        <Grid item xs={12} sm={6} md={4}>
          <Button
            fullWidth
            variant="contained"
            color="primary"
            disabled={valera.alcohol >= 50 || valera.fatigue >= 10 || actionLoading === 'work'}
            onClick={() => handleAction('work')}
          >
            {actionLoading === 'work' ? <CircularProgress size={24} /> : 'Работать'}
          </Button>
        </Grid>

        <Grid item xs={12} sm={6} md={4}>
          <Button
            fullWidth
            variant="outlined"
            color="success"
            disabled={actionLoading === 'nature'}
            onClick={() => handleAction('nature')}
          >
            {actionLoading === 'nature' ? <CircularProgress size={24} /> : 'Созерцать'}
          </Button>
        </Grid>

        <Grid item xs={12} sm={6} md={4}>
          <Button
            fullWidth
            variant="outlined"
            color="warning"
            disabled={actionLoading === 'wine'}
            onClick={() => handleAction('wine')}
          >
            {actionLoading === 'wine' ? <CircularProgress size={24} /> : 'Вино + сериал'}
          </Button>
        </Grid>

        <Grid item xs={12} sm={6} md={4}>
          <Button
            fullWidth
            variant="contained"
            color="warning"
            disabled={actionLoading === 'bar'}
            onClick={() => handleAction('bar')}
          >
            {actionLoading === 'bar' ? <CircularProgress size={24} /> : 'Сходить в бар'}
          </Button>
        </Grid>

        <Grid item xs={12} sm={6} md={4}>
          <Button
            fullWidth
            variant="contained"
            color="error"
            disabled={actionLoading === 'marginals'}
            onClick={() => handleAction('marginals')}
          >
            {actionLoading === 'marginals' ? <CircularProgress size={24} /> : 'Выпить с маргиналами'}
          </Button>
        </Grid>

        <Grid item xs={12} sm={6} md={4}>
          <Button
            fullWidth
            variant="outlined"
            color="info"
            disabled={actionLoading === 'subway'}
            onClick={() => handleAction('subway')}
          >
            {actionLoading === 'subway' ? <CircularProgress size={24} /> : 'Петь в метро'}
          </Button>
        </Grid>

        <Grid item xs={12} sm={6} md={4}>
          <Button
            fullWidth
            variant="contained"
            color="secondary"
            disabled={actionLoading === 'sleep'}
            onClick={() => handleAction('sleep')}
          >
            {actionLoading === 'sleep' ? <CircularProgress size={24} /> : 'Спать'}
          </Button>
        </Grid>
      </Grid>

      <Box sx={{ mt: 4, textAlign: 'center' }}>
        <Button
          variant="outlined"
          onClick={() => window.history.back()}
        >
          ← Назад к списку
        </Button>
      </Box>
    </Container>
  );
}