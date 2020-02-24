using System;

namespace Altseed
{
    [Serializable]
    internal enum SceneStatus : int
    {
        /// <summary>
        /// ���o�^
        /// �C���X�^���X�������̃f�t�H���g
        /// </summary>
        Free,

        /// <summary>
        /// �t�F�[�h�C���J�n
        /// </summary>
        FadingIn,

        /// <summary>
        /// �A�b�v�f�[�g�J�n
        /// ���p���������s�ς�
        /// </summary>
        StartUpdating,

        /// <summary>
        /// �J�ڂ��I�����A�o�^����Ă���
        /// </summary>
        Updated,

        /// <summary>
        /// �t�F�[�h�A�E�g�J�n
        /// </summary>
        FadingOut,

        /// <summary>
        /// �A�b�v�f�[�g�I��
        /// ���p���������s�J�n
        /// </summary>
        StopUpdating,

        /// <summary>
        /// �j���҂�
        /// </summary>
        WaitDisposed,

        /// <summary>
        /// �j���ς�
        /// </summary>
        Disposed,

        /// <summary>
        /// ���m
        /// </summary>
        UnKnown
    }
}